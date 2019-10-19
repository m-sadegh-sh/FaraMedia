using System.Web.Mvc;
using Fara.Core;
using Fara.Core.Caching;
using Fara.Core.Infrastructure;
using Fara.Services.Localization;
using Fara.Services.Topics;
using Fara.Web.Extensions;
using Fara.Web.Infrastructure.Cache;
using Fara.Web.Models.Topics;

namespace Fara.Web.Controllers
{
    public class TopicController : BaseFaraController
    {
        

        private readonly ITopicService _topicService;
        private readonly IWorkContext _workContext;
        private readonly ILocalizationService _localizationService;
        private readonly ICacheManager _cacheManager;

        

        

        private TopicModel PrepareTopicModel(string systemName)
        {
            var topic = _topicService.GetTopicBySystemName(systemName);
            if (topic == null)
                return null;

            var model = topic.ToModel();
            if (model.IsPasswordProtected)
            {
                model.Title = string.Empty;
                model.Body = string.Empty;
            }
            return model;
        }

        public TopicController(ITopicService topicService,
            ILocalizationService localizationService,
            IWorkContext workContext)
        {
            this._topicService = topicService;
            this._workContext = workContext;
            this._localizationService = localizationService;

            
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("fara_cache_static");
        }

        

        

        public ActionResult TopicDetails(string systemName)
        {
            var cacheKey = string.Format(ModelCacheEventConsumer.TOPIC_MODEL_KEY, systemName, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () => PrepareTopicModel(systemName));

            if (cacheModel == null)
                return RedirectToAction("Index", "Home");
            return View("TopicDetails", cacheModel);
        }

        public ActionResult TopicDetailsPopup(string systemName)
        {
            var cacheKey = string.Format(ModelCacheEventConsumer.TOPIC_MODEL_KEY, systemName, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () => PrepareTopicModel(systemName));

            if (cacheModel == null)
                return RedirectToAction("Index", "Home");

            ViewBag.IsPopup = true;
            return View("TopicDetails", cacheModel);
        }

        [ChildActionOnly]
        
        public ActionResult TopicBlock(string systemName)
        {
            var cacheKey = string.Format(ModelCacheEventConsumer.TOPIC_MODEL_KEY, systemName, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () => PrepareTopicModel(systemName));

            if (cacheModel == null)
                return Content(string.Empty);

            return PartialView(cacheModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Authenticate(int id, string password)
        {
            var authResult = false;
            var title = string.Empty;
            var body = string.Empty;
            var error = string.Empty;

            var topic = _topicService.GetTopicById(id);

            if (topic != null)
            {
                if (topic.Password != null && topic.Password.Equals(password))
                {
                    authResult = true;
                    title = topic.GetLocalized(x => x.Title);
                    body = topic.GetLocalized(x => x.Body);
                }
                else
                {
                    error = _localizationService.GetResource("Topic.WrongPassword");
                }
            }
            return Json(new { Authenticated = authResult, Title = title, Body = body, Error = error });
        }

        
    }
}
