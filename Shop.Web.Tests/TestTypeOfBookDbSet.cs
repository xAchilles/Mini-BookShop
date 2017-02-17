using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Web.Tests
{
    class TestTypeOfBookDbSet : TestDbSet<TypeOfBook>
    {
        public override TypeOfBook Find(params object[] keyValues)
        {
            return this.SingleOrDefault(type => type.ID == (int)keyValues.Single());
        }
    }
}
