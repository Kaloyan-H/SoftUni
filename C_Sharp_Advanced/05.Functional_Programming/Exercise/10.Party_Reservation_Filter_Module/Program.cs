using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Party_Reservation_Filter_Module
{
    class Program
    {

        public class FilterInfo
        {
            public FilterInfo() { }

            public FilterInfo(string filterType, string parameter)
            {
                this.FilterType = filterType;
                this.Parameter = parameter;
            }

            public string FilterType { get; set; }
            public string Parameter { get; set; }

        }

        public static void BetterRemoveAll(List<FilterInfo> list, FilterInfo filterInfo)
        {
            Func<FilterInfo, FilterInfo, bool> checker = (f1, f2) => f1.FilterType == f2.FilterType && f1.Parameter == f2.Parameter;

            var tempArr = list.ToArray();
            var tempList = tempArr.ToList();

            foreach (var item in tempList)
            {
                if (checker(item, filterInfo))
                {
                    list.Remove(item);
                }
            }

        }
        static void Main(string[] args)
        {
            List<string> invitationList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<FilterInfo> filterParametersList = new List<FilterInfo>();

            Func<FilterInfo, FilterInfo, bool> checker = (f1, f2) => f1.FilterType == f2.FilterType && f1.Parameter == f2.Parameter; 

            Action<List<string>, FilterInfo> filter = (l, fp) =>
            {
                if (fp.FilterType == "Starts With")
                {
                    var temp = l.ToArray();
                    var tempInvList = temp.ToList();
                    foreach (var item in tempInvList)
                    {
                        if (item.StartsWith(fp.Parameter))
                        {
                            l.Remove(item);
                        }
                    }
                }
                else if (fp.FilterType == "Ends with")
                {
                    var temp = l.ToArray();
                    var tempInvList = temp.ToList();
                    foreach (var item in tempInvList)
                    {
                        if (item.EndsWith(fp.Parameter))
                        {
                            l.Remove(item);
                        }
                    }
                }
                else if (fp.FilterType == "Length")
                {
                    var temp = l.ToArray();
                    var tempInvList = temp.ToList();
                    foreach (var item in tempInvList)
                    {
                        if (item.Length == int.Parse(fp.Parameter))
                        {
                            l.Remove(item);
                        }
                    }
                }
                else
                {
                    var temp = l.ToArray();
                    var tempInvList = temp.ToList();
                    foreach (var item in tempInvList)
                    {
                        if (item.Contains(fp.Parameter))
                        {
                            l.Remove(item);
                        }
                    }
                }
            };

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Print")
                {
                    break;
                }

                string addOrRemove = cmdArgs[0];
                string filterType = cmdArgs[1];
                string parameter = cmdArgs[2];

                if (addOrRemove == "Add filter")
                {
                    filterParametersList.Add(new FilterInfo(filterType, parameter));
                }
                else
                {
                    BetterRemoveAll(filterParametersList, new FilterInfo(filterType, parameter));
                }
            }

            foreach (var filterInfo in filterParametersList)
            {
                filter(invitationList, filterInfo);
            }

            Console.WriteLine(string.Join(" ", invitationList));
        }
    }
}
