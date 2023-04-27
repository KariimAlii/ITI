﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class DepartmentReadDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
    }
}
