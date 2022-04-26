using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClasses
{
    public class UserOrg
    {
        public Tuple<string, string> SplitPoint(string toSplit)
        {
            if (toSplit != null)
            {
                try
                {
                    string[] split = toSplit.Split('.');

                    if (split.Length > 1 && split.Length < 3)
                        return Tuple.Create(split[0], split[1]);
                    else
                    {
                        return null;
                    }
                }
                catch (System.NullReferenceException)
                {
                    return null;
                }

            }


            return null;
        }

        public Tuple<string, string> SplitComma(string toSplit)
        {
            if (toSplit != null)
            {
                try
                {
                    string[] split = toSplit.Split(',');

                    if (split.Length > 1 && split.Length < 3)
                        return Tuple.Create(split[0], split[1]);
                    else
                    {
                        return null;
                    }
                }
                catch (System.NullReferenceException)
                {
                    return null;
                }
            }

            return null;
        }
    }
}
