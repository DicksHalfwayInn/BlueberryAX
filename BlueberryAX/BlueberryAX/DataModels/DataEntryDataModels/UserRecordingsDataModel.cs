using System;
using System.Collections.Generic;
using System.Text;

namespace BlueberryAX
{
    /// <summary>
    /// Represents all the entries for a user
    /// </summary>
    public class UserRecordingsDataModel 
    {
        public List<GlucoseLevelRecordingDataModel> GlucoseLevelRecordings { get; set; }
        = new List<GlucoseLevelRecordingDataModel>();

        public List<CarbIntakeRecordingDataModel> CarbIntakeRecordings { get; set; }
        = new List<CarbIntakeRecordingDataModel>();

        public List<ExersizeRecordingDataModel> ExersizeRecordings { get; set; }
        = new List<ExersizeRecordingDataModel>();

        public List<LongTermInsulinRecordingDataModel> LongTermInsulinRecordings { get; set; }
        = new List<LongTermInsulinRecordingDataModel>();

        public List<ShortTermInsulinRecordingDataModel> ShortTermInsulinRecordings { get; set; }
        = new List<ShortTermInsulinRecordingDataModel>();

        public List<TimeSegmentViewModel> TimeSegments { get; set; }
        = new List<TimeSegmentViewModel>();

        public UserRecordingsDataModel()
        {
            LoadDummyData();
            // TODO: I have entered the dummy data in order, but it will have to be sorted 
            // by date of recording first in order for the badge color background to work
            // when we set it in the Container View Model, PopulateBadgesWithGlucoseRecordings method

        }

        public void LoadDummyData()
        {
            DateTime DummyDataDateTime = new DateTime(2019, 12, 24, 0, 0, 0);

            DateTime currentDate = DateTime.Now;

            var cd = currentDate;

            DateTime currentDateZeroed = new DateTime(cd.Year, cd.Month, cd.Day, 0, 0, 0);

            var daysToAdd = (currentDateZeroed - DummyDataDateTime);

            var newDate = DummyDataDateTime + daysToAdd;

            var yr = newDate.Year;

            var mn = newDate.Month;

            var dy = newDate.Day;

            var todayMinusOne = new DateTime(yr, mn, dy).AddDays(-1);

            var todayMinusTwo = new DateTime(yr, mn, dy).AddDays(-2);

            var todayMinusThree = new DateTime(yr, mn, dy).AddDays(-3);

            var todayMinusFour = new DateTime(yr, mn, dy).AddDays(-4);

            GlucoseLevelRecordings = new List<GlucoseLevelRecordingDataModel>
            {
                ///
                /// readings for dec 20 2019
                ///

                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 40,

                    StartTime = todayMinusFour.AddHours(1).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 67,
                    StartTime = todayMinusFour.AddHours(3).AddMinutes(30).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 100,
                    StartTime = todayMinusFour.AddHours(7).AddMinutes(5).AddSeconds(0),

                    Duration = new TimeSpan(0,0,1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 67,
                    StartTime = todayMinusFour.AddHours(10).AddMinutes(31).AddSeconds(0),

                    Duration = new TimeSpan(0,0,1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 130,
                    StartTime = todayMinusFour.AddHours(13).AddMinutes(18).AddSeconds(0),

                    Duration = new TimeSpan(0,0,1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 152,
                    StartTime = todayMinusFour.AddHours(16).AddMinutes(18).AddSeconds(0),

                    Duration = new TimeSpan(0,0,1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 130,
                    StartTime = todayMinusFour.AddHours(19).AddMinutes(14).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 55,
                    StartTime = todayMinusFour.AddHours(22).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)
                },
            ///
            /// readings for dec 21 2019
            ///
            new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 10,
                    StartTime = todayMinusThree.AddHours(2).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 67,
                    StartTime = todayMinusThree.AddHours(4).AddMinutes(30).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 30,
                    StartTime = todayMinusThree.AddHours(8).AddMinutes(5).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 35,
                    StartTime = todayMinusThree.AddHours(11).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 84,
                    StartTime = todayMinusThree.AddHours(14).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 64,
                    StartTime = todayMinusThree.AddHours(17).AddMinutes(18).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 49,
                    StartTime = todayMinusThree.AddHours(20).AddMinutes(5).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 94,
                    StartTime = todayMinusThree.AddHours(21).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },///
                /// readings for dec 22 2019
                ///
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 105,
                    StartTime = todayMinusTwo.AddHours(1).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 79,
                    StartTime = todayMinusTwo.AddHours(3).AddMinutes(30).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 58,
                    StartTime = todayMinusTwo.AddHours(7).AddMinutes(5).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 49,
                    StartTime = todayMinusTwo.AddHours(19).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 60,
                    StartTime = todayMinusTwo.AddHours(13).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 85,
                    StartTime = todayMinusTwo.AddHours(16).AddMinutes(18).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 85,
                    StartTime = todayMinusTwo.AddHours(19).AddMinutes(5).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 67,
                    StartTime = todayMinusTwo.AddHours(22).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                ///
                /// readings for dec 23 2019
                ///
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 120,
                    StartTime = todayMinusOne.AddHours(2).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 125,
                    StartTime = todayMinusOne.AddHours(4).AddMinutes(30).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 105,
                    StartTime = todayMinusOne.AddHours(8).AddMinutes(5).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 150,
                    StartTime = todayMinusOne.AddHours(11).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 145,
                    StartTime = todayMinusOne.AddHours(14).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 104,
                    StartTime = todayMinusOne.AddHours(17).AddMinutes(18).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 97,
                    StartTime = todayMinusOne.AddHours(20).AddMinutes(5).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)

                },
                new GlucoseLevelRecordingDataModel
                {
                    GlucoseLevel = 67,
                    StartTime = todayMinusOne.AddHours(21).AddMinutes(31).AddSeconds(0),
                    Duration = new TimeSpan(0, 0, 1)
                }

            };

            CarbIntakeRecordings = new List<CarbIntakeRecordingDataModel>
            {
                new CarbIntakeRecordingDataModel
                {
                    CarbIntakeAmount = 3,
                    StartTime = todayMinusOne.AddHours(1).AddMinutes(45).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)

                },
                new CarbIntakeRecordingDataModel
                {
                    CarbIntakeAmount = 2,
                    StartTime = todayMinusOne.AddHours(9).AddMinutes(45).AddSeconds(0),
                    Duration = new TimeSpan(0,0,1)

                }

            };

            ExersizeRecordings = new List<ExersizeRecordingDataModel>
            {
                new ExersizeRecordingDataModel
                {
                    StartTime = todayMinusOne.AddHours(6).AddMinutes(45).AddSeconds(0),
                    Duration = new TimeSpan(0,0,180,0),
                    Quality = ExersizeQualityEnum.MaximumIntensity

                },
                new ExersizeRecordingDataModel
                {
                    StartTime = todayMinusTwo.AddHours(4).AddMinutes(15).AddSeconds(0),
                    Duration = new TimeSpan(0,0,60,0),
                    Quality = ExersizeQualityEnum.MediumIntensity

                }

            };

            ShortTermInsulinRecordings = new List<ShortTermInsulinRecordingDataModel>
            {
                //new ShortTermInsulinRecordingDataModel
                //{
                //    StartTime = new DateTime(2019, 12, 22, 0, 45, 0),
                //    Duration = new TimeSpan(0,4,0,0),
                //    Amount = 8

                //},
                new ShortTermInsulinRecordingDataModel
                {
                    StartTime = todayMinusTwo.AddHours(22).AddMinutes(45).AddSeconds(0),
                    Duration = new TimeSpan(0,4,0,0),
                    Amount = 10

                }

            };

        }




    }
}

