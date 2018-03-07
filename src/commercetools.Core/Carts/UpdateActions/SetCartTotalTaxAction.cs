using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commercetools.Core.Common;

using Newtonsoft.Json;

namespace commercetools.Core.Carts.UpdateActions
{
    /// <summary>
    /// The total tax amount of the cart can be set if it has the ExternalAmount TaxMode.
    /// </summary>
    /// <see href="https://dev.commercetools.com/http-api-projects-carts.html#set-cart-total-tax"/>
    public class SetCartTotalTaxAction : UpdateAction
    {
        #region Properties

        [JsonProperty(PropertyName = "externalTotalGross")]
        public Money ExternalTotalGross { get; set; }

        [JsonProperty(PropertyName = "externalTaxPortions")]
        public List<TaxPortion> ExternalTaxPortions { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetCartTotalTaxAction(Money externalTotalGross)
        {
            this.Action = "setCartTotalTax";
            this.ExternalTotalGross = externalTotalGross;
        }

        #endregion
    }
}
