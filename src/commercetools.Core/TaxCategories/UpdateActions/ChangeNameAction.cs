﻿using commercetools.Core.Common;
using Newtonsoft.Json;

namespace commercetools.Core.TaxCategories.UpdateActions
{
    /// <summary>
    /// Change Name
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-taxCategories.html#change-name"/>
    public class ChangeNameAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name</param>
        public ChangeNameAction(string name)
        {
            this.Action = "changeName";
            this.Name = name;
        }

        #endregion
    }
}
