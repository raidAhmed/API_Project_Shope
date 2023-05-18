
using System;
using System.Collections.Generic;
using System.Text;

namespace Agricultural.Application.Wrapper
{
    public class DtResult<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
        public string error { get; set; }

        public static DtResult<T> DataTableFactory()
        {
            return new DtResult<T>();
        }
        public static DtResult<T> DataTableFactory(int recordTotal,int recordFiltered, IEnumerable<T> data)
        {
            return new DtResult<T>
            {
                recordsTotal = recordTotal,
                recordsFiltered = recordFiltered,
                data = data
            };
        }
        public static DtResult<T> DataTableFactory(int recordTotal,int recordFiltered, IEnumerable<T> data,string error)
        {
            return new DtResult<T>
            {
                recordsTotal = recordTotal,
                recordsFiltered = recordFiltered,
                data = data,
                error = error
            };
        }
        public static DtResult<T> DataTableFactory(int draw,int recordTotal,int recordFiltered, IEnumerable<T> data,string error)
        {
            return new DtResult<T>
            {
                draw = draw,
                recordsTotal = recordTotal,
                recordsFiltered = recordFiltered,
                data = data,
                error = error
            };
        }
    }
}
