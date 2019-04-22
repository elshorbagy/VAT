﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VAT.Data;

namespace VAT.Service
{
    public interface IExtractData
    {
        Task<List<VatData>> GetLowestVatCountries(int countriesCount);
        Task<List<VatData>> GetHighestVatCountries(int countriesCount);        
    }
}
