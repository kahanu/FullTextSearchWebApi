using ExpressionBuilder.Common;
using System.Collections.Generic;

namespace FTS.Library.Search.Models
{
    public class SearchCriteria
    {
        public string FieldName { get; set; } = string.Empty;
        public string OperationName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Connector Connector { get; set; } = Connector.Or;

        /// <summary>
        /// The field value is a comma-separated array of possible values.
        /// Example: if you want to search for a Last Name that StartsWith Jack or John, ['Jack, John']
        /// </summary>
        public List<object> FieldValue { get; set; } = new List<object>();
    }
}
