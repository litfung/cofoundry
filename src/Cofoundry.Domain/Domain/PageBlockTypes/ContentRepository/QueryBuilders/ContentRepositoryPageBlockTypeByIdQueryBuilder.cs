﻿using Cofoundry.Domain.Extendable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public class ContentRepositoryPageBlockTypeByIdQueryBuilder
        : IContentRepositoryPageBlockTypeByIdQueryBuilder
        , IExtendableContentRepositoryPart
    {
        private readonly int _pageBlockTypeId;

        public ContentRepositoryPageBlockTypeByIdQueryBuilder(
            IExtendableContentRepository contentRepository,
            int pageBlockTypeId
            )
        {
            ExtendableContentRepository = contentRepository;
            _pageBlockTypeId = pageBlockTypeId;
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        public Task<PageBlockTypeSummary> AsSummaryAsync()
        {
            var query = new GetPageBlockTypeSummaryByIdQuery(_pageBlockTypeId);
            return ExtendableContentRepository.ExecuteQueryAsync(query);
        }

        public Task<PageBlockTypeDetails> AsDetailsAsync()
        {
            var query = new GetPageBlockTypeDetailsByIdQuery(_pageBlockTypeId);
            return ExtendableContentRepository.ExecuteQueryAsync(query);
        }
    }
}
