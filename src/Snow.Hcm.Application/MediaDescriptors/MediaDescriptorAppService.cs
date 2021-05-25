using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.BlobStoring;

namespace Snow.Hcm.MediaDescriptors
{
    public class MediaDescriptorAppService:HcmAppService, IMediaDescriptorAppService
    {
        public MediaDescriptorAppService([NotNull] IBlobContainer<MediaContainer> mediaContainer,
            [NotNull] IMediaDescriptorRepository mediaDescriptorRepository,
            [NotNull] MediaDescriptorManager mediaDescriptorManager,
            [NotNull] IMediaDescriptorDefinitionStore mediaDescriptorDefinitionStore)
        {
            MediaContainer = mediaContainer ?? throw new ArgumentNullException(nameof(mediaContainer));
            MediaDescriptorRepository = mediaDescriptorRepository ?? throw new ArgumentNullException(nameof(mediaDescriptorRepository));
            MediaDescriptorManager = mediaDescriptorManager ?? throw new ArgumentNullException(nameof(mediaDescriptorManager));
            MediaDescriptorDefinitionStore = mediaDescriptorDefinitionStore ?? throw new ArgumentNullException(nameof(mediaDescriptorDefinitionStore));
        }

        protected IBlobContainer<MediaContainer> MediaContainer { get; }
        protected IMediaDescriptorRepository MediaDescriptorRepository { get; }
        protected MediaDescriptorManager MediaDescriptorManager { get; }
        protected IMediaDescriptorDefinitionStore MediaDescriptorDefinitionStore { get; }
        
        public virtual async Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream)
        {
            var definition = await MediaDescriptorDefinitionStore.GetAsync(entityType);

            /* TODO: Shouldn't CreatePolicies be a dictionary and we check for inputStream.EntityType? */
            await CheckAnyOfPoliciesAsync(definition.CreatePolicies);

            using (var stream = inputStream.File.GetStream())
            {
                var newEntity = await MediaDescriptorManager.CreateAsync(entityType, inputStream.Name, inputStream.File.ContentType, inputStream.File.ContentLength ?? 0);

                await MediaContainer.SaveAsync(newEntity.Id.ToString(), stream);
                await MediaDescriptorRepository.InsertAsync(newEntity);

                return ObjectMapper.Map<MediaDescriptor, MediaDescriptorDto>(newEntity);
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var mediaDescriptor = await MediaDescriptorRepository.GetAsync(id);

            var definition = await MediaDescriptorDefinitionStore.GetAsync(mediaDescriptor.EntityType);

            /* TODO: Shouldn't DeletePolicies be a dictionary and we check for inputStream.EntityType? */
            await CheckAnyOfPoliciesAsync(definition.DeletePolicies);

            await MediaContainer.DeleteAsync(id.ToString());
            await MediaDescriptorRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Checks given policies until finding granted policy. If none of them is granted, throws <see cref="AbpAuthorizationException"/>
        /// </summary>
        /// <param name="policies">Policies to be checked.</param>
        /// <exception cref="AbpAuthorizationException">Thrown when none of policies is granted.</exception>
        protected async Task CheckAnyOfPoliciesAsync([NotNull] IEnumerable<string> policies)
        {
            Check.NotNull(policies, nameof(policies));

            foreach (var policy in policies)
            {
                if (await AuthorizationService.IsGrantedAsync(policy))
                {
                    return;
                }
            }

            throw new AbpAuthorizationException();
        }
    }
}
