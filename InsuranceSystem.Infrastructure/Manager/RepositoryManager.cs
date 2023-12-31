﻿using AutoMapper;
using InsuranceSystem.Application.Interface;
using InsuranceSystem.Core.Interface;
using InsuranceSystem.Infrastructure.DBContext;
using InsuranceSystem.Infrastructure.Repositories;

namespace InsuranceSystem.Infrastructure.Manager
{
    public class RepositoryManager : IRepositoryManager
	{
        private readonly DatabaseContext _db;
        private IMapper _mapper;
        private IPolicyHolderRepository _PolicyHolderRepository;
        private IClaimsRepository _ClaimsRepository;

        public RepositoryManager(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IPolicyHolderRepository PolicyHolder
        {
            get
            {
                _PolicyHolderRepository ??= new PolicyHolderRepository(_db, _mapper);
                return _PolicyHolderRepository;
            }
        }

        public IClaimsRepository Claims
        {
            get
            {
                _ClaimsRepository ??= new ClaimsRepository(_db, _mapper);

                return _ClaimsRepository;
            }
        }

        public async Task<int> SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}

