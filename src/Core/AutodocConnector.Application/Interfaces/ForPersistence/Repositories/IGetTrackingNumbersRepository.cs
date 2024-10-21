using AutodocConnector.Domain.Parcels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories
{
    public interface IGetTrackingNumbersRepository
    {
        /// <summary>
        /// Get parcel entity list by orderID
        /// </summary>
        /// <param name="orderID">orderID from request</param>
        /// <returns>List of Parcel entity</returns>
        Task<List<Parcel>> GetParcelsByOrderID(string orderID);
    }
}
