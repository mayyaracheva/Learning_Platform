﻿using System;

namespace Poodle.Data.EntityModels
{
    public abstract class Entity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }

    }
}
