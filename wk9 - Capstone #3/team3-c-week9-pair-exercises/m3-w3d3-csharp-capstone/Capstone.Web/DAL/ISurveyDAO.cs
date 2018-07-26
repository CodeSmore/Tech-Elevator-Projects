using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
        bool InsertSurvey(SurveyEntry newReview);
        List<SurveyResult> GetTopFiveParks();
    }
}
