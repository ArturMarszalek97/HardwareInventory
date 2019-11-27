using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public static class CacheObjectExtensions
    {
        public static void Add<T>(this HashSet<CacheObject<T>> set, T _object)
        {
            set.Add(new CacheObject<T>(_object));
        }

        public static void AddSaved<T>(this HashSet<CacheObject<T>> set, T _object)
        {
            var obj = new CacheObject<T>(_object);
            obj.SetSaveTime();
            set.Add(obj);
        }
    }
}
