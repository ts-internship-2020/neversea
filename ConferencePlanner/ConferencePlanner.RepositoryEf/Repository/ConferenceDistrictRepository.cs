﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceDistrictRepository : IDistrictRepository
    {
        private readonly neverseaContext _dbContext;

        public ConferenceDistrictRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DistrictModel> GetDistricts()
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            List<DistrictModel> districtsModel = new List<DistrictModel>();
            districts = _dbContext.DictionaryDistrict.ToList();

            districtsModel = districts.Select(d => new DistrictModel()
            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode = d.DictionaryDistrictCode
            }).ToList();


            return districtsModel;
        }
        public List<DistrictModel> GetDistricts(string keyword)
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            List<DistrictModel> districtsModel = new List<DistrictModel>();
            districts = _dbContext.DictionaryDistrict.Where(d => d.DictionaryDistrictCode.Contains(keyword) || d.DictionaryDistrictName.Contains(keyword)).ToList();

            districtsModel = districts.Select(d => new DistrictModel()
            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode = d.DictionaryDistrictCode
            }).ToList();


            return districtsModel;
        }
        public List<DistrictModel> GetDistrictsByCountryId(int key)
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            List<DistrictModel> districtsModel = new List<DistrictModel>();
            districts = _dbContext.DictionaryDistrict.Where(d => d.DictionaryCountryId == key).ToList();

            districtsModel = districts.Select(d => new DistrictModel()
            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode = d.DictionaryDistrictCode
            }).ToList();


            return districtsModel;
        }
        public List<DistrictModel> GetConferenceDistrictByCountryId(int countryId)
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            List<DistrictModel> districtsModel = new List<DistrictModel>();
            districts = _dbContext.DictionaryDistrict.Where(d => d.DictionaryCountryId == countryId).ToList();

            districtsModel = districts.Select(d => new DistrictModel()
            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode = d.DictionaryDistrictCode,
                CountryId = d.DictionaryCountryId
            }).ToList();


            return districtsModel;
        }
        public DistrictModel GetConferenceDistrictByCityId(int cityId)
        {
            DistrictModel districtModel = new DistrictModel();
            DictionaryDistrict district = new DictionaryDistrict();

            ConferenceCityModel city = new ConferenceCityModel();
            DictionaryCity cityDictionary = new DictionaryCity();
            cityDictionary = _dbContext.DictionaryCity.Where(l => l.DictionaryCityId == cityId).FirstOrDefault();
            int districtId = cityDictionary.DictionaryDistrictId;

            district = _dbContext.DictionaryDistrict.Where(c => c.DictionaryDistrictId == districtId).FirstOrDefault();
            districtModel.DistrictId = district.DictionaryDistrictId;
            districtModel.DistrictName = district.DictionaryDistrictName;
            districtModel.DistrictCode = district.DictionaryDistrictCode;
            districtModel.CountryId = district.DictionaryCountryId;
            return districtModel;
        }
        public void UpdateDistrict(int districtId, string districtName, string districtCode, int countryId)
        {
            try
            {
                DictionaryDistrict districtEdited = _dbContext.DictionaryDistrict.Find(districtId);
                districtEdited.DictionaryDistrictName = districtName;
                districtEdited.DictionaryDistrictCode = districtCode;
                Console.WriteLine("Vreau sa fac update la countrId " + countryId);
                districtEdited.DictionaryCountryId = countryId;
                _dbContext.SaveChanges();
            }
            catch
            {
                return;
            }
        }
        public void InsertDistrict(string districtName, string districtCode, int countryId)
        {
            try
            {


                int id = 0;
                List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
                districts = _dbContext.DictionaryDistrict.ToList();
                id = districts.Max(d => d.DictionaryDistrictId);
                id++;

                _dbContext.DictionaryDistrict.Add(new DictionaryDistrict()
                {
                    DictionaryDistrictId = id,
                    DictionaryDistrictName = districtName,
                    DictionaryDistrictCode = districtCode,
                    DictionaryCountryId = countryId
                });

                _dbContext.SaveChanges();
            } 
            catch
            {
                return;
            }
        }

 
        public void DeleteDistrict(int districtId, int countryId)
        {
            try
            {


                List<DictionaryDistrict> dictionaryDistrict = new List<DictionaryDistrict>();

                dictionaryDistrict = _dbContext.DictionaryDistrict.Select(d => new DictionaryDistrict()
                {

                    DictionaryDistrictId = d.DictionaryDistrictId,
                    DictionaryCountryId = d.DictionaryCountryId
                }).Where(d => d.DictionaryDistrictId == districtId).ToList();
                //  && d.DictionaryCountryId == countryId
                List<DistrictModel> maxId = dictionaryDistrict.Select(d => new DistrictModel()

                {
                    DistrictId = d.DictionaryDistrictId,
                    DistrictName = d.DictionaryDistrictName
                }).Where(d => d.DistrictId == districtId).ToList();

                DictionaryDistrict district = new DictionaryDistrict();
                _dbContext.Remove(dictionaryDistrict[0]);

                _dbContext.SaveChanges();
            }
            catch
            {
                return;
            }
        }
    }
}
