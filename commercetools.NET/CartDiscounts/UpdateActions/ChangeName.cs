﻿using commercetools.Common;
using Newtonsoft.Json;

namespace commercetools.CartDiscounts.UpdateActions
{
    public class ChangeName: UpdateAction
    {
        [JsonProperty(PropertyName = "name")]
        public LocalizedString Name { get; }

        public ChangeName(LocalizedString name)
        {
            this.Action = "changeName";
            this.Name = name;
        }
    }
}
