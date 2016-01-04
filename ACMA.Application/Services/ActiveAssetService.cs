using ACMA.Domain.Entities.ActiveAsset;
using ACMA.Domain.Entities.RFID;
using repositoriesDomain = ACMA.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACMA.Domain.Entities.Commom;
using ACMA.Domain.Entities.NetworkBandwidth;

namespace ACMA.Application.Services
{
    public class ActiveAssetService : IDisposable
    {
        private repositoriesDomain.ActiveAssetRepository _activeAssetRepository { get; set; }
        private repositoriesDomain.PlaceRepository _placeRepository { get; set; }
        private repositoriesDomain.RfidRepository _rfidRepository { get; set; }
        private repositoriesDomain.ConfigurationRepository _configurationRepository { get; set; }

        public ActiveAssetService()
        {
            this._activeAssetRepository = new repositoriesDomain.ActiveAssetRepository();
            this._placeRepository = new repositoriesDomain.PlaceRepository();
            this._rfidRepository = new repositoriesDomain.RfidRepository();
            this._configurationRepository = new repositoriesDomain.ConfigurationRepository();
        }

        //Salva os dados já formatados no banco
        public void SaveFormattedRawData(List<RawData> rawDataList)
        {
            var assetList = new List<Asset>();

            foreach (var rawData in rawDataList)
            {
                //Pesquisa centro de custo correspondente pelo IP leitor
                int idCostCenter = _placeRepository.GetCostCenterIdBy(rawData.IpAddress);
                //Pesquisa a unidade através do IP do leitor
                int idUnit = _placeRepository.GetUnitIdBy(rawData.IpAddress);
                //Pesquisa o leitor através do IP do leitor
                int idReader = _rfidRepository.GetReaderIdBy(rawData.IpAddress);
                //Pesquisa o id da tag através do IP do leitor
                int idItem = _rfidRepository.GetItemIdBy(rawData.TagCode);

                var asset = new Asset()
                {
                    IdCostCenter = idCostCenter,
                    IdItem = idItem,
                    IdUnit = idUnit                    
                };
                assetList.Add(asset);
            }

            //Aguarda o tempo necessário da chave de configuração para envio dos dados
            _activeAssetRepository.SaveFormattedRawData(assetList);
        }

        public void Dispose()
        {
        }
    }
}
