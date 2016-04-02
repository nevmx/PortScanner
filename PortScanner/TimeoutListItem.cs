using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    class TimeoutListItem
    {
        public string DisplayMember { get; set; }
        public int ValueMember { get; set; }

        private static int[] _times =
        {
            500, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000
        };

        public static List<TimeoutListItem> CreateTimeoutListItems()
        {
            var returnList = new List<TimeoutListItem>();

            for (int i = 0; i < _times.Length; i++)
            {
                returnList.Add(new TimeoutListItem
                {
                    DisplayMember = String.Format("{0} ms", _times[i]),
                    ValueMember = _times[i]
                });
            }

            return returnList;
        }
    }
}
