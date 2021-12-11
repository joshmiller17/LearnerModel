using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace JoshAaronMiller.LearnerModel
{
    public static class Utilities
    {
        /// <summary>
        /// A simple implementation of Python's defaultdict, which creates a default value if the key does not exist.
        /// Adapted from https://stackoverflow.com/questions/15622622/analogue-of-pythons-defaultdict
        /// </summary>
        public class DefaultDictionary<Key, Value> : Dictionary<Key, Value> where Value : new()
        {
            public new Value this[Key key]
            {
                get
                {
                    Value val;
                    if (!TryGetValue(key, out val))
                    {
                        val = new Value();
                        Add(key, val);
                    }
                    return val;
                }
                set { base[key] = value; }
            }
        }
    }
}