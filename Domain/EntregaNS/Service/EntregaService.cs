using Amazon.S3;
using Amazon.S3.Model;
using Domain.EntregaNS.Interfaces;
using Domain.EntregaNS.Query;
using Domain.Models.EntregaNS;
using Domain.Queue.Interface;
using Domain.Queue.Service;
using Microsoft.AspNetCore.Http;

namespace Domain.EntregaNS.Service
{
    public class EntregaService : IEntregaService
    {
        private readonly IEntregaRepository _entregaRepository;
        private readonly IAmazonS3 _s3Client;
        private readonly IQueueService _queueService;
        public EntregaService(IEntregaRepository entregaRepository, IAmazonS3 s3Client, IQueueService queueService)
        {
            _entregaRepository = entregaRepository;
            _s3Client = s3Client;
            _queueService = queueService;
        }

        public async Task<bool> AdicionarEntrega(IFormFile arquivo, int alunoId, int tarefaId)
        {
            var filename = $"EntregaAluno{alunoId}Tarefa{tarefaId}";
            var request = new PutObjectRequest()
            {
                BucketName = "tarefasbucket",
                Key = filename + ".png",
                InputStream = arquivo.OpenReadStream(),
                CannedACL = S3CannedACL.PublicRead
            };
            request.Metadata.Add("Content-Type", arquivo.ContentType);

            try
            {
                
                await _s3Client.PutObjectAsync(request);
                var bucketUrl = $"https://tarefasbucket.s3-sa-east-1.amazonaws.com/{filename}.png";
                var entrega = EntregaFactory.CriarEntrega(new Uri(bucketUrl), tarefaId, alunoId);
                _queueService.Enqueue(entrega);
                _entregaRepository.Adicionar(entrega);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Entrega> Buscar(BuscarEntregaQuery query)
        {
            try
            {
                return _entregaRepository.Buscar(query);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
