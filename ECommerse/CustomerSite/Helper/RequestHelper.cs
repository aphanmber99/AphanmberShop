using Shared.Enum;

namespace CustomerSite.Helper
{
    public class RequestHelper
    {
        public static string GetQueryString(int categoryId, int pageSize = 0, int page = 0, SortProduct? sort = null){
            var queryString ="?";
            queryString += nameof(categoryId)+"="+categoryId;
            if(sort!=null) queryString += "&&"+nameof(sort)+"="+sort;
            queryString += "&&"+nameof(pageSize)+"="+pageSize;
            queryString += "&&"+nameof(page)+"="+page;
            return queryString;
            // ?categoryId=0&&sort=null&&pageSize=0&&page=0
        }
    }
}