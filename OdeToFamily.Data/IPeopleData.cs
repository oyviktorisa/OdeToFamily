using OdeToFamily.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFamily.Data
{
    public interface IPeopleData
    {
        IEnumerable<People> GetAll();
    }
}
