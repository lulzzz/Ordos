﻿using Ordos.DataService.Data;
using Ordos.Core.Models;
using Ordos.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordos.DataService.Services
{
    public static class DatabaseService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static List<Device> Devices { get; private set; }
        public static string CompanyName { get; set; }
        public static string CompanyNameLabel { get; } = "CompanyName";

        public static void Init()
        {
            LoadDevices();
            LoadApplicationSettings();
        }

        public static void LoadDevices()
        {
            using (var context = new SystemContext())
            {
                Devices = context.Devices
                                 .Include(d => d.DisturbanceRecordings).AsNoTracking()
                                 .ToList();
            }
        }

        public static void LoadApplicationSettings()
        {
            using (var context = new SystemContext())
            {
                if (context.ConfigurationValues == null) return;
                CompanyName = context.ConfigurationValues.FirstOrDefault(x => x.Id.Contains(CompanyNameLabel))?.Value;
            }
        }

        public static void UpdateIEDConnectionStatus(Device device, bool isConnected)
        {
            try
            {
                using (var context = new SystemContext())
                {
                    var dev = context.Devices.FirstOrDefault(x => x.Id.Equals(device.Id));
                    if (dev == null) return;

                    dev.IsConnected = isConnected;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
            Logger.Trace($"{device.FullName} - {device.IPAddress} - Connection {(isConnected ? "Successful" : "Failed")}");
        }

        public static void AddDRtoDB(Device device, string drFilename, DateTime drDate)
        {
            try
            {
                using (var context = new SystemContext())
                {
                    var dev = context.Devices
                        .Include(x => x.DisturbanceRecordings)
                        .ToList()
                        .FirstOrDefault(x => x.Id.Equals(device.Id));

                    if (dev.DisturbanceRecordings.Any(x => x.Name.Equals(drFilename) && drDate.Equals(x.TriggerTime)))
                        return;

                    dev.DisturbanceRecordings.Add(new DisturbanceRecording()
                    {
                        DeviceId = device.Id,
                        Name = drFilename,
                        TriggerTime = drDate,
                    });
                    context.SaveChanges();

                    //TODO: Me permitirá modificar los devices entre medio?
                    LoadDevices();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public static void AddDRtoDB(Device device, string filename, string destinationFilename)
        {
            try
            {
                if (!destinationFilename.ToUpper().EndsWith(FileNameExtensions.CFGExtension)) return;

                var dates = ComtradeExtensions.GetDRDateTimes(destinationFilename);
                var drDate = dates.FirstOrDefault();

                using (var context = new SystemContext())
                {
                    var dev = context.Devices
                                     .Include(x => x.DisturbanceRecordings)
                                     .ToList()
                                     .FirstOrDefault(x => x.Id.Equals(device.Id));

                    if (dev.DisturbanceRecordings.Any(x => x.Name.Equals(filename.Split(".").First()) && drDate.Equals(x.TriggerTime)))
                        return;

                    dev.DisturbanceRecordings.Add(new DisturbanceRecording()
                    {
                        DeviceId = device.Id,
                        Name = filename.Split(".").First(),
                        TriggerTime = drDate,
                    });
                    context.SaveChanges();

                    //TODO: Me permitirá modificar los devices entre medio?
                    LoadDevices();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }
    }
}
