﻿using System.Collections.Generic;

namespace ClientApi.Api.Models
{
    public class CharatersList
    {
        public IEnumerable<Character> Characters { get; set; }
        public bool IsDev { get; set; }
        public int RbBalance { get; set; }
        public int NameChangeCost { get; set; }
    }
}