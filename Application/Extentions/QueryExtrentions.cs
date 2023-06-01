using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Extentions;

public static class QueryExtrentions
{
    /*public static IQueryable<T> FilterBy<T>(this IQueryable<T> query, EntityBaseDto request)
    where T:EntityBaseDto
    {
        foreach (var prop in typeof(T).GetProperties())
        {
            var reqProp = request.GetType().GetProperties().FirstOrDefault(c => c.Name == prop.Name);
            if(reqProp == null)
                continue;

            var reqPropValue = reqProp.GetValue(request);
            
            if(reqPropValue == null)
                continue;
            
            //query = query.
            
        }
    }*/

    public static async Task<bool> EntityIsExists<T>(this IQueryable<T> query,Guid id)
        where T : EntityBase
    {
        return await query.Where(c => c.Id == id).AnyAsync();
    }
}