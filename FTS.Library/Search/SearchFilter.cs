using ExpressionBuilder.Generics;
using ExpressionBuilder.Interfaces;
using ExpressionBuilder.Operations;
using FTS.Library.Search.Models;
using System;
using System.Collections.Generic;

namespace FTS.Library.Search
{
    /// <summary>
    /// The generic search feature that uses the ExpressionBuilder assembly to
    /// dynamically build the lambda expression for the filter.  In order to 
    /// use this correctly, the UI needs to provide the correct request collection.
    /// </summary>
    /// <example>
    /// var search = new SearchFilter<Customers>(_fieldsList);
    /// Filter<Customers> filter = search.Filter(request.SearchCriteria);
    /// 
    /// using (var context = new YourEFContext())
    /// {
    ///     var customerList = context.Customers.AsQueryable();
    ///     var results = customerList.Where(filter)
    ///         .Select(d => ...).ToList();
    ///         
    ///     response.List = results;
    /// }
    /// </example>
    /// <typeparam name="T">The entity type being passed into the ExpressionBuilder filter method.</typeparam>
    public class SearchFilter<T> where T : class
    {

        #region ctors

        /// <summary>
        /// The search filter that dynamically builds the Linq lambda expression.
        /// </summary>
        public SearchFilter()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// The filter function.
        /// </summary>
        /// <param name="list">The list of search criteria to be used to dynamically build the lambda Linq expression.</param>
        /// <returns></returns>
        public Filter<T> Filter(List<SearchCriteria> list)
        {
            var filter = new Filter<T>();
            FilterStatementBuilder(filter, list);
            return filter;
        }

        #endregion

        #region Private Methods

        private void FilterStatementBuilder(IFilter filter, List<SearchCriteria> list)
        {
            foreach (var criteria in list)
            {
                if (criteria.Type == "Decimal")
                {
                    foreach (var dec in criteria.FieldValue)
                    {
                        Decimal fieldValue = Convert.ToDecimal(dec);
                        filter.By(criteria.FieldName, Operation.ByName(criteria.OperationName), fieldValue, default(Decimal), criteria.Connector);
                    }
                }
                else if (criteria.Type == "DateTimeOffset")
                {
                    foreach (var date in criteria.FieldValue)
                    {
                        DateTimeOffset fieldValue = new DateTimeOffset(DateTime.Parse(date.ToString()));
                        filter.By(criteria.FieldName, Operation.ByName(criteria.OperationName), fieldValue, default(DateTimeOffset?), criteria.Connector);
                    }
                }
                else if (criteria.Type == "Int16")
                {
                    foreach (var num in criteria.FieldValue)
                    {
                        Int16 fieldValue = Convert.ToInt16(num);
                        filter.By(criteria.FieldName, Operation.ByName(criteria.OperationName), fieldValue, default(Int16), criteria.Connector);
                    }
                }
                else
                {
                    foreach (var str in criteria.FieldValue)
                    {
                        filter.By(criteria.FieldName, Operation.ByName(criteria.OperationName), str, null, criteria.Connector);
                    }
                }
            }
        }

        #endregion
    }
}
