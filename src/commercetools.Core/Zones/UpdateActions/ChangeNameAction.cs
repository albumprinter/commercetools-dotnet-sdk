﻿using commercetools.Core.Common;
using Newtonsoft.Json;

namespace commercetools.Core.Zones.UpdateActions
{
    /// <summary>
    /// ChangeNameAction
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-zones.html#change-name"/>
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
