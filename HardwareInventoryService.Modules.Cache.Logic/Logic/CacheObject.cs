using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public class CacheObject<T>
    {
        private T _object;

        private DateTime _lastModified;

        private DateTime? _saveTime;

        public CacheObject()
        {
            this._lastModified = DateTime.Now;
            this._saveTime = null;
        }

        public CacheObject(T obj) : this()
        {
            this._object = obj;
        }

        public T Object
        {
            get { return this._object; }
            set 
            { 
                this._object = value; 
                this._lastModified = DateTime.Now; 
            }
        }

        public DateTime LastModifiedDate
        {
            get { return this._lastModified; }
        }

        public DateTime? SaveTime
        {
            get { return this._saveTime; }
        }

        public void SetSaveTime()
        {
            this._saveTime = DateTime.Now;
        }

        public void SetSaveTime(DateTime date)
        {
            this._saveTime = date;
        }
    }
}
