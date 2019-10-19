using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Fara.Core;
using Fara.Core.Domain.Catalog;
using Fara.Services.Catalog;
using Fara.Services.Localization;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Framework.UI.Paging;

namespace Fara.Web.Models.Catalog
{
    public class CatalogPagingFilteringModel : BasePageableModel
    {
        

        public CatalogPagingFilteringModel()
        {
            this.PriceRangeFilter = new PriceRangeFilterModel();
            this.SpecificationFilter = new SpecificationFilterModel();
        }

        

        

        public int CategoryId { get; set; }

        public int PublisherId { get; set; }

        
        
        
        public PriceRangeFilterModel PriceRangeFilter { get; set; }

        
        
        
        public SpecificationFilterModel SpecificationFilter { get; set; }

        
        
        
        [FaraResourceDisplayName("Categories.OrderBy")]
        public int OrderBy { get; set; }

        
        
        
        [FaraResourceDisplayName("Categories.ViewMode")]
        public string ViewMode { get; set; }
        

        

        

        public class PriceRangeFilterModel : BaseFaraModel
        {
            

            private const string QUERYSTRINGPARAM = "price";

            

            

            public PriceRangeFilterModel()
            {
                this.Items = new List<PriceRangeFilterItem>();
            }

            

            

            
            
            
            protected virtual IList<PriceRange> GetPriceRangeList(string priceRangesStr)
            {
                var priceRanges = new List<PriceRange>();
                if (string.IsNullOrWhiteSpace(priceRangesStr))
                    return priceRanges;
                string[] rangeArray = priceRangesStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str1 in rangeArray)
                {
                    string[] fromTo = str1.Trim().Split(new char[] { '-' });

                    decimal? from = null;
                    if (!string.IsNullOrEmpty(fromTo[0]) && !string.IsNullOrEmpty(fromTo[0].Trim()))
                        from = decimal.Parse(fromTo[0].Trim(), new CultureInfo("en-US"));

                    decimal? to = null;
                    if (!string.IsNullOrEmpty(fromTo[1]) && !string.IsNullOrEmpty(fromTo[1].Trim()))
                        to = decimal.Parse(fromTo[1].Trim(), new CultureInfo("en-US"));

                    priceRanges.Add(new PriceRange() { From = from, To = to });
                }
                return priceRanges;
            }

            protected virtual string ExcludeQueryStringParams(string url, IWebHelper webHelper)
            {
                var excludedQueryStringParams = "pagenumber"; 
                if (!string.IsNullOrEmpty(excludedQueryStringParams))
                {
                    string[] excludedQueryStringParamsSplitted = excludedQueryStringParams.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string exclude in excludedQueryStringParamsSplitted)
                        url = webHelper.RemoveQueryString(url, exclude);
                }

                return url;
            }

            

            

            public virtual PriceRange GetSelectedPriceRange(IWebHelper webHelper, string priceRangesStr)
            {
                string range = webHelper.QueryString<string>(QUERYSTRINGPARAM);
                if (string.IsNullOrEmpty(range))
                    return null;
                string[] fromTo = range.Trim().Split(new char[] { '-' });
                if (fromTo.Length == 2)
                {
                    decimal? from = null;
                    if (!string.IsNullOrEmpty(fromTo[0]) && !string.IsNullOrEmpty(fromTo[0].Trim()))
                        from = decimal.Parse(fromTo[0].Trim(), new CultureInfo("en-US"));
                    decimal? to = null;
                    if (!string.IsNullOrEmpty(fromTo[1]) && !string.IsNullOrEmpty(fromTo[1].Trim()))
                        to = decimal.Parse(fromTo[1].Trim(), new CultureInfo("en-US"));

                    var priceRangeList = GetPriceRangeList(priceRangesStr);
                    foreach (var pr in priceRangeList)
                    {
                        if (pr.From == from && pr.To == to)
                            return pr;
                    }
                }
                return null;
            }

            public virtual void LoadPriceRangeFilters(string priceRangeStr, IWebHelper webHelper, IPriceFormatter priceFormatter)
            {
                var priceRangeList = GetPriceRangeList(priceRangeStr);
                if (priceRangeList.Count > 0)
                {
                    this.Enabled = true;

                    var selectedPriceRange = GetSelectedPriceRange(webHelper, priceRangeStr);

                    this.Items = priceRangeList.ToList().Select(x =>
                    {
                        
                        var item = new PriceRangeFilterItem();
                        if (x.From.HasValue)
                            item.From = priceFormatter.FormatPrice(x.From.Value, true, false);
                        if (x.To.HasValue)
                            item.To = priceFormatter.FormatPrice(x.To.Value, true, false);
                        string fromQuery = string.Empty;
                        if (x.From.HasValue)
                            fromQuery = x.From.Value.ToString(new CultureInfo("en-US"));
                        string toQuery = string.Empty;
                        if (x.To.HasValue)
                            toQuery = x.To.Value.ToString(new CultureInfo("en-US"));

                        
                        if (selectedPriceRange != null
                            && selectedPriceRange.From == x.From
                            && selectedPriceRange.To == x.To)
                            item.Selected = true;

                        
                        string url = webHelper.ModifyQueryString(webHelper.GetThisPageUrl(true), QUERYSTRINGPARAM + "=" + fromQuery + "-" + toQuery, null);
                        url = ExcludeQueryStringParams(url, webHelper);
                        item.FilterUrl = url;


                        return item;
                    }).ToList();

                    if (selectedPriceRange != null)
                    {
                        
                        string url = webHelper.RemoveQueryString(webHelper.GetThisPageUrl(true), QUERYSTRINGPARAM);
                        url = ExcludeQueryStringParams(url, webHelper);
                        this.RemoveFilterUrl = url;
                    }
                }
                else
                {
                    this.Enabled = false;
                }
            }
            
            

            
            public bool Enabled { get; set; }
            public IList<PriceRangeFilterItem> Items { get; set; }
            public string RemoveFilterUrl { get; set; }

            
        }

        public class PriceRangeFilterItem : BaseFaraModel
        {
            public string From { get; set; }
            public string To { get; set; }
            public string FilterUrl { get; set; }
            public bool Selected { get; set; }
        }

        public class SpecificationFilterModel : BaseFaraModel
        {
            

            private const string QUERYSTRINGPARAM = "specs";

            

            

            public SpecificationFilterModel()
            {
                this.AlreadyFilteredItems = new List<SpecificationFilterItem>();
                this.NotFilteredItems = new List<SpecificationFilterItem>();
            }

            

            

            protected virtual string ExcludeQueryStringParams(string url, IWebHelper webHelper)
            {
                var excludedQueryStringParams = "pagenumber"; 
                if (!string.IsNullOrEmpty(excludedQueryStringParams))
                {
                    string[] excludedQueryStringParamsSplitted = excludedQueryStringParams.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string exclude in excludedQueryStringParamsSplitted)
                    {
                        url = webHelper.RemoveQueryString(url, exclude);
                    }
                }

                return url;
            }

            protected virtual IList<SpecificationAttributeOptionFilter> GetAlreadyFilteredSpecs(ISpecificationAttributeService specificationAttributeService, 
                IWebHelper webHelper, IWorkContext workContext)
            {
                var result = new List<SpecificationAttributeOptionFilter>();

                var optionIds = GetAlreadyFilteredSpecOptionIds(webHelper);
                foreach (var id in optionIds)
                {
                    var sao = specificationAttributeService.GetSpecificationAttributeOptionById(id);
                    if (sao != null)
                    {
                        var sa = sao.SpecificationAttribute;
                        if (sa != null)
                        {
                            result.Add(new SpecificationAttributeOptionFilter
                            {
                                SpecificationAttributeId = sa.Id,
                                SpecificationAttributeName = sa.GetLocalized(x => x.Name),
                                DisplayOrder = sa.DisplayOrder,
                                SpecificationAttributeOptionId = sao.Id,
                                SpecificationAttributeOptionName = sao.GetLocalized(x => x.Name)
                            });
                        }
                    }
                }

                return result;
            }

            protected virtual IList<SpecificationAttributeOptionFilter> GetNotFilteredSpecs(int categoryId, 
                ISpecificationAttributeService specificationAttributeService, IWebHelper webHelper, IWorkContext workContext)
            {
                
                var result = specificationAttributeService.GetSpecificationAttributeOptionFilter(categoryId, workContext);

                
                var alreadyFilteredOptions = GetAlreadyFilteredSpecs(specificationAttributeService, webHelper, workContext);
                foreach (var saof1 in alreadyFilteredOptions)
                {
                    var query = from s in result
                                where s.SpecificationAttributeId == saof1.SpecificationAttributeId
                                select s;

                    var toRemove = query.ToList();
                    foreach (var saof2 in toRemove)
                        result.Remove(saof2);
                }
                return result;
            }

            protected virtual string GenerateFilteredSpecQueryParam(IList<int> optionIds)
            {
                string result = string.Empty;

                if (optionIds == null || optionIds.Count == 0)
                    return result;

                for (int i = 0; i < optionIds.Count; i++)
                {
                    result += optionIds[i];
                    if (i != optionIds.Count - 1)
                        result += ",";
                }
                return result;
            }

            

            

            public virtual List<int> GetAlreadyFilteredSpecOptionIds(IWebHelper webHelper)
            {
                var result = new List<int>();

                string alreadyFilteredSpecsStr = webHelper.QueryString<string>(QUERYSTRINGPARAM);
                if (string.IsNullOrWhiteSpace(alreadyFilteredSpecsStr))
                    return result;

                foreach (var spec in alreadyFilteredSpecsStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    int specId = 0;
                    int.TryParse(spec.Trim(), out specId);
                    if (!result.Contains(specId))
                        result.Add(specId);
                }
                return result;
            }

            public virtual void LoadSpecsFilters(Category category, 
                ISpecificationAttributeService specificationAttributeService, IWebHelper webHelper, 
                IWorkContext workContext)
            {
                if (category == null)
                    throw new ArgumentNullException("category");

                var alreadyFilteredOptions = GetAlreadyFilteredSpecs(specificationAttributeService, webHelper, workContext);
                var notFilteredOptions = GetNotFilteredSpecs(category.Id, 
                    specificationAttributeService, webHelper, workContext);

                if (alreadyFilteredOptions.Count > 0 || notFilteredOptions.Count > 0)
                {
                    this.Enabled = true;
                    
                    this.AlreadyFilteredItems = alreadyFilteredOptions.ToList().Select(x =>
                    {
                        var item = new SpecificationFilterItem();
                        item.SpecificationAttributeName = x.SpecificationAttributeName;
                        item.SpecificationAttributeOptionName = x.SpecificationAttributeOptionName;

                        return item;
                    }).ToList();

                    this.NotFilteredItems = notFilteredOptions.ToList().Select(x =>
                    {
                        var item = new SpecificationFilterItem();
                        item.SpecificationAttributeName = x.SpecificationAttributeName;
                        item.SpecificationAttributeOptionName = x.SpecificationAttributeOptionName;

                        
                        var alreadyFilteredOptionIds = GetAlreadyFilteredSpecOptionIds(webHelper);
                        if (!alreadyFilteredOptionIds.Contains(x.SpecificationAttributeOptionId))
                            alreadyFilteredOptionIds.Add(x.SpecificationAttributeOptionId);
                        string newQueryParam = GenerateFilteredSpecQueryParam(alreadyFilteredOptionIds);
                        string filterUrl = webHelper.ModifyQueryString(webHelper.GetThisPageUrl(true), QUERYSTRINGPARAM + "=" + newQueryParam, null);
                        filterUrl = ExcludeQueryStringParams(filterUrl, webHelper);
                        item.FilterUrl = filterUrl;


                        return item;
                    }).ToList();


                    
                    string removeFilterUrl = webHelper.RemoveQueryString(webHelper.GetThisPageUrl(true), QUERYSTRINGPARAM);
                    removeFilterUrl = ExcludeQueryStringParams(removeFilterUrl, webHelper);
                    this.RemoveFilterUrl = removeFilterUrl;
                }
                else
                {
                    this.Enabled = false;
                }
            }

            

            
            public bool Enabled { get; set; }
            public IList<SpecificationFilterItem> AlreadyFilteredItems { get; set; }
            public IList<SpecificationFilterItem> NotFilteredItems { get; set; }
            public string RemoveFilterUrl { get; set; }

            
        }

        public class SpecificationFilterItem : BaseFaraModel
        {
            public string SpecificationAttributeName { get; set; }
            public string SpecificationAttributeOptionName { get; set; }
            public string FilterUrl { get; set; }
        }

        
    }
}