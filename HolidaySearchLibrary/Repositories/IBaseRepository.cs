using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public List<T> LoadData();
    }
}
