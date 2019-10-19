namespace FaraMedia.Data.Mapping {
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	using FaraMedia.Core.Domain;
	using FaraMedia.Data.NHibernating.Conventions;

	using NHibernate.Mapping.ByCode;
	using NHibernate.Mapping.ByCode.Conformist;

	using Utilities.DataTypes.ExtensionMethods;
	using Utilities.Reflection.ExtensionMethods;

	public abstract class MapBase<T> : ClassMapping<T> where T : class {
		public void Set<TElement>(Expression<Func<T, IEnumerable<TElement>>> property) where TElement : EntityBase {
			Set(property,
			    spm => {
				    spm.Cascade(Cascade.All | Cascade.DeleteOrphans);
				    spm.Inverse(true);
			    },
			    cer => cer.OneToMany());
		}

		protected void SetController<TInverseEntity>(Expression<Func<T, IEnumerable<TInverseEntity>>> controllingProperty) where TInverseEntity : EntityBase {
			var controllingPropertyName = controllingProperty.GetPropertyName().
			                                                  Singularize();
			var controllingColumnName = IdentityBuilder.BuildKeyName(controllingPropertyName);
			var inverseColumnName = IdentityBuilder.BuildKeyName(typeof (T).Name);

			var schema = IdentityBuilder.BuildSchema(typeof (T).Namespace);
			var tableName = IdentityBuilder.BuildTableName<T>(controllingPropertyName);

			Set(controllingProperty,
			    spm => {
				    spm.Cascade(Cascade.All | Cascade.DeleteOrphans);
				    spm.Schema(schema);
				    spm.Table(tableName);
				    spm.Key(km => km.Column(inverseColumnName));
			    },
			    em => em.ManyToMany(m => m.Column(controllingColumnName)));
		}

		protected void SetInverse<TControllingEntity>(Expression<Func<T, IEnumerable<TControllingEntity>>> inverseProperty,
		                                              Expression<Func<TControllingEntity, IEnumerable<T>>> controllingProperty) where TControllingEntity : class {
			var controllingPropertyName = controllingProperty.GetPropertyName().
			                                                  Singularize();
			var controllingColumnName = IdentityBuilder.BuildKeyName(controllingPropertyName);
			var inverseColumnName = IdentityBuilder.BuildKeyName(typeof (TControllingEntity).Name);

			var schema = IdentityBuilder.BuildSchema(typeof (TControllingEntity).Namespace);
			var tableName = IdentityBuilder.BuildTableName<TControllingEntity>(controllingPropertyName);

			Set(inverseProperty,
			    spm => {
				    spm.Schema(schema);
				    spm.Table(tableName);
				    spm.Inverse(true);
				    spm.Key(km => km.Column(controllingColumnName));
			    },
			    em => em.ManyToMany(mtmm => mtmm.Column(inverseColumnName)));
		}
	}
}