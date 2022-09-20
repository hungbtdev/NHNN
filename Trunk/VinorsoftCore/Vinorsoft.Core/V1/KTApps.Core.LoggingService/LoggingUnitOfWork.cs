using KTApps.Core.LoggingService.Interface;
using KTApps.Core.LoggingService.Repository;
using KTApps.Core.EF;
using KTApps.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Core.LoggingService
{
    public class LoggingUnitOfWork : UnitOfWork, ILoggingUnitOfWork
    {
        readonly ILoggingDbContext loggingDbContext;
        public LoggingUnitOfWork(ILoggingDbContext context) : base(context)
        {
            loggingDbContext = context;
        }
        public override IDomainRepository<T> Repository<T>()
        {
            return new LoggingRepository<T>(loggingDbContext);
        }
    }
}
