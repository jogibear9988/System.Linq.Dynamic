using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Linq.Dynamic
{
    /// <summary>
    /// Provides a base class for dynamic objects created by using the <see cref="DynamicQueryable.Select(IQueryable,string,object[])"/> 
    /// method. For internal use only.
    /// </summary>
    public class DynamicClass : DynamicObject
    {
        Dictionary<string, object> _properties = new Dictionary<string, object>();

        //public DynamicClass(IEnumerable<KeyValuePair<string, object>> propertyValues)
        //{
        //    foreach (var pair in propertyValues)
        //    {
        //        _properties.Add(pair.Key, pair.Value);
        //    }
        //}

        public DynamicClass(KeyValuePair<string, object> _1)
        {
            _properties.Add(_1.Key, _1.Value);
        }

        public DynamicClass(KeyValuePair<string, object> _1, KeyValuePair<string, object> _2)
        {
            _properties.Add(_1.Key, _1.Value);
            _properties.Add(_2.Key, _2.Value);
        }

        public DynamicClass(KeyValuePair<string, object> _1, KeyValuePair<string, object> _2, KeyValuePair<string, object> _3)
        {
            _properties.Add(_1.Key, _1.Value);
            _properties.Add(_2.Key, _2.Value);
            _properties.Add(_3.Key, _3.Value);
        }

        public DynamicClass(KeyValuePair<string, object> _1, KeyValuePair<string, object> _2, KeyValuePair<string, object> _3, KeyValuePair<string, object> _4)
        {
            _properties.Add(_1.Key, _1.Value);
            _properties.Add(_2.Key, _2.Value);
            _properties.Add(_3.Key, _3.Value);
            _properties.Add(_4.Key, _4.Value);
        }

        public object this[string name]
        {
            get
            {
                object result;
                if (_properties.TryGetValue(name, out result))
                    return result;

                return null;
            }
            set
            {
                if (_properties.ContainsKey(name))
                    _properties[name] = value;
                else
                    _properties.Add(name, value);
            }
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;
            _properties.TryGetValue(name, out result);

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var name = binder.Name;
            if (_properties.ContainsKey(name))
                _properties[name] = value;
            else
                _properties.Add(name, value);

            return true;
        }
    }
}
