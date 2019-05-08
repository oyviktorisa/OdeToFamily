using OdeToFamily.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFamily.Data
{
    public interface IRelationsData
    {
        IEnumerable<Relations> GetAll();
    }
}
