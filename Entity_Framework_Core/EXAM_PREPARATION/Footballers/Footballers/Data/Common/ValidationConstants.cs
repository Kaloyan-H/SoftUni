using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Common
{
    public static class ValidationConstants
    {
        // Footballer
        public const int FootballerNameMaxLength = 40;
        public const int FootballerNameMinLength = 2;

        // Team
        public const int TeamNameMaxLength = 40;
        public const int TeamNameMinLength = 3;
        public const int TeamNationalityMaxLength = 40;
        public const int TeamNationalityMinLength = 2;

        // Coach
        public const int CoachNameMaxLength = 40;
        public const int CoachNameMinLength = 2;
    }
}
