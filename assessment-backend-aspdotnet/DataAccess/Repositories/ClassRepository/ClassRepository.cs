﻿using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using AutoMapper;

namespace assessment_backend_aspdotnet.DataAccess.Repositories.ClassRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AssessmentContext _dbContext;
        private readonly IMapper _mapper;
        public ClassRepository(AssessmentContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<ClassDto> CreateClass(ClassDto cls)
        {
            Class convDbObj = _mapper.Map<Class>(cls);

            decimal maxId = _dbContext.Classes.Any<Class>() ? _dbContext.Classes.Max<Class, decimal>(c => c.Id) : 0;
            convDbObj.Id = maxId + 1;

            _dbContext.Classes.Add(convDbObj);
            await _dbContext.SaveChangesAsync();

            return cls;
        }
    }
}
