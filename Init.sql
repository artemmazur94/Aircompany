USE [AircompanyDB]
GO
SET IDENTITY_INSERT [dbo].[Photos] ON 
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (6, N'/uploadFiles/6ebe6644-8786-475a-8a5d-ad4c0c7ff12f.jpg', N'6ebe6644-8786-475a-8a5d-ad4c0c7ff12f', N'300px-Lufthansa_Airbus_A320-211_D-AIQT_01.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (7, N'/uploadFiles/7ab3d8ec-5354-4f7a-97e6-7bff136c63bf.jpg', N'7ab3d8ec-5354-4f7a-97e6-7bff136c63bf', N'300px-Turkish_Airlines,_Airbus_A330-300_TC-JNL_NRT_(23708073592).jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (8, N'/uploadFiles/38fbc8ed-229a-4cc9-8c2f-45662015fb7b.jpg', N'38fbc8ed-229a-4cc9-8c2f-45662015fb7b', N'300px-Антонов_Ан-148_01-02,_Киев_-_Антонов_(Гостомель)_RP29608.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (9, N'/uploadFiles/48e8f95b-d2bd-4c12-8f91-0a1e144c0f9a.jpg', N'48e8f95b-d2bd-4c12-8f91-0a1e144c0f9a', N'300px-COMAC_ARJ21_Gu.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (10, N'/uploadFiles/2d5fb3dc-e281-4b72-b54c-3c6f4279167b.png', N'2d5fb3dc-e281-4b72-b54c-3c6f4279167b', N'VZqUF86.png')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (11, N'/uploadFiles/d395ca5a-fbb8-43f2-8153-fd98c58c1f2d.jpg', N'd395ca5a-fbb8-43f2-8153-fd98c58c1f2d', N'Bombardier-CRJ-200.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (12, N'/uploadFiles/d6fc9b72-7939-4531-bedd-70175051f808.jpg', N'd6fc9b72-7939-4531-bedd-70175051f808', N'300px-South_African_Airlink_Boeing_737-200_Advanced_Smith.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (13, N'/uploadFiles/38e750c7-3230-430b-bd0c-395b73b28815.jpg', N'38e750c7-3230-430b-bd0c-395b73b28815', N'Boeing-777-9X.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (14, N'/uploadFiles/5192788a-de74-4349-8035-eab78a8bc142.jpg', N'5192788a-de74-4349-8035-eab78a8bc142', N'Fokker-100.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (15, N'/uploadFiles/cbfa6662-f905-4067-943c-ae8f0ff8b42d.JPG', N'cbfa6662-f905-4067-943c-ae8f0ff8b42d', N'Saab-2000-Skywork.JPG')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (16, N'/uploadFiles/a4ad35d3-f0d1-44ca-a94b-ac3b25703332.jpg', N'a4ad35d3-f0d1-44ca-a94b-ac3b25703332', N'2-1.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (17, N'/uploadFiles/9939f094-3f10-4a08-aab9-efa478395d59.jpg', N'9939f094-3f10-4a08-aab9-efa478395d59', N'dnepr-3.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (18, N'/uploadFiles/3e9bfdb9-44a0-4fce-b835-65cbec1b0c36.jpg', N'3e9bfdb9-44a0-4fce-b835-65cbec1b0c36', N'content__________.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (19, N'/uploadFiles/00620391-f801-45da-883b-8c7622fb65d5.jpg', N'00620391-f801-45da-883b-8c7622fb65d5', N'aeroport_L-viv_imeni_danyla_galyc-kogo-13952575822.jpg')
GO
INSERT [dbo].[Photos] ([Id], [Path], [Guid], [Filename]) VALUES (20, N'/uploadFiles/65d8feaa-135e-4c79-bf9f-8563f4ef2c44.jpg', N'65d8feaa-135e-4c79-bf9f-8563f4ef2c44', N'images.jpg')
GO
SET IDENTITY_INSERT [dbo].[Photos] OFF
GO
SET IDENTITY_INSERT [dbo].[Airports] ON 
GO
INSERT [dbo].[Airports] ([Id], [Code], [Country], [City], [PhotoId]) VALUES (5, N'KBP', N'Ukraine', N'Kyiv', 16)
GO
INSERT [dbo].[Airports] ([Id], [Code], [Country], [City], [PhotoId]) VALUES (6, N'DNK', N'Ukraine', N'Dnipro', 17)
GO
INSERT [dbo].[Airports] ([Id], [Code], [Country], [City], [PhotoId]) VALUES (7, N'OZH', N'Ukraine', N'Zaporizhia', 18)
GO
INSERT [dbo].[Airports] ([Id], [Code], [Country], [City], [PhotoId]) VALUES (8, N'LWO', N'Ukraine', N'Lviv', 19)
GO
INSERT [dbo].[Airports] ([Id], [Code], [Country], [City], [PhotoId]) VALUES (9, N'ODS', N'Ukraine', N'Odessa', 20)
GO
SET IDENTITY_INSERT [dbo].[Airports] OFF
GO
SET IDENTITY_INSERT [dbo].[Planes] ON 
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (12, N'A320', N'Airbus', 890, 6)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (13, N'Airbus', N'A330-300', 870, 7)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (14, N'Antonov', N'An-148', 820, 8)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (15, N'Comac', N'ARJ21', 870, 9)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (16, N'BAC', N'1-11', 800, 10)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (17, N'Bombardier', N'CRJ-100/200', 860, 11)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (18, N'Boeing', N'737-700', 850, 12)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (19, N'Boeing', N'777-9', 950, 13)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (20, N'Fokker', N'100', 800, 14)
GO
INSERT [dbo].[Planes] ([Id], [Manufacturer], [Model], [MaxSpeed], [PhotoId]) VALUES (21, N'Saab', N'2000', 650, 15)
GO
SET IDENTITY_INSERT [dbo].[Planes] OFF
GO
SET IDENTITY_INSERT [dbo].[Flights] ON 
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (4, 5, 9, CAST(N'2017-11-29T00:00:00.000' AS DateTime), CAST(N'2017-11-29T00:00:00.000' AS DateTime), 15, 0, NULL, 5, 20)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (5, 7, 6, CAST(N'2017-11-29T08:30:00.000' AS DateTime), CAST(N'2017-11-29T08:30:00.000' AS DateTime), 21, 0, NULL, 5, 22)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (6, 5, 8, CAST(N'2017-11-28T15:00:00.000' AS DateTime), CAST(N'2017-11-28T15:00:00.000' AS DateTime), 16, 0, NULL, 6, 18)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (7, 8, 6, CAST(N'2017-11-29T22:00:00.000' AS DateTime), CAST(N'2017-11-29T22:00:00.000' AS DateTime), 14, 0, NULL, 5, 0)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (8, 9, 5, CAST(N'2017-11-29T04:00:00.000' AS DateTime), CAST(N'2017-11-29T04:00:00.000' AS DateTime), 12, 0, NULL, 7, 25)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (9, 5, 9, CAST(N'2017-11-30T18:00:00.000' AS DateTime), CAST(N'2017-11-30T18:00:00.000' AS DateTime), 13, 0, NULL, 5, 0)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (10, 5, 7, CAST(N'2017-11-28T06:00:00.000' AS DateTime), CAST(N'2017-11-28T06:00:00.000' AS DateTime), 21, 0, NULL, 7, 0)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (11, 6, 8, CAST(N'2017-12-01T15:00:00.000' AS DateTime), CAST(N'2017-12-01T15:00:00.000' AS DateTime), 20, 0, NULL, 5, 15)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (12, 8, 9, CAST(N'2017-11-29T22:00:00.000' AS DateTime), CAST(N'2017-11-29T22:00:00.000' AS DateTime), 18, 0, NULL, 10, 25)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (13, 6, 8, CAST(N'2017-11-30T01:00:00.000' AS DateTime), CAST(N'2017-11-30T01:00:00.000' AS DateTime), 19, 0, NULL, 6, 0)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (14, 8, 5, CAST(N'2017-11-29T08:00:00.000' AS DateTime), CAST(N'2017-11-29T08:00:00.000' AS DateTime), 15, 0, NULL, 5, 22)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (15, 5, 7, CAST(N'2017-11-28T00:00:00.000' AS DateTime), CAST(N'2017-11-28T00:00:00.000' AS DateTime), 17, 0, NULL, 0, 0)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (16, 7, 5, CAST(N'2017-11-30T18:00:00.000' AS DateTime), CAST(N'2017-11-30T18:00:00.000' AS DateTime), 12, 0, NULL, 4, 20)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (17, 6, 8, CAST(N'2017-11-30T12:00:00.000' AS DateTime), CAST(N'2017-11-30T12:00:00.000' AS DateTime), 12, 0, NULL, 7, 0)
GO
INSERT [dbo].[Flights] ([Id], [DepartureAirportId], [ArivingAirportId], [DepartureDateTime], [ArivingDateTime], [PlaneId], [IsDeleted], [RemoveExecutorId], [HandLuggage], [Luggage]) VALUES (18, 5, 6, CAST(N'2017-11-30T08:00:00.000' AS DateTime), CAST(N'2017-11-30T08:00:00.000' AS DateTime), 13, 0, NULL, 5, 20)
GO
SET IDENTITY_INSERT [dbo].[Flights] OFF
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 5, CAST(650.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 6, CAST(600.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 7, CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 8, CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 9, CAST(800.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 10, CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 11, CAST(900.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 12, CAST(250.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 13, CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 15, CAST(700.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 16, CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 17, CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (1, 18, CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 4, CAST(2000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 7, CAST(800.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 8, CAST(750.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 12, CAST(700.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 14, CAST(2000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 16, CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (2, 17, CAST(700.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (3, 4, CAST(3000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (3, 6, CAST(1200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (3, 8, CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (3, 14, CAST(3000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (3, 16, CAST(600.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SectorTypePrices] ([SeatTypeId], [FlightId], [Price]) VALUES (3, 17, CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AirportLocalizations] ([AirportId], [LanguageId], [Name], [Description]) VALUES (5, 1, N'Boryspil International Airport', N'Boryspil International Airport is an international airport in Boryspil, 29 km (18 mi) east of Kiev, the capital of Ukraine. It is the country''s largest airport, serving 65% of its passenger air traffic, including all its intercontinental flights and a majority of international flights.')
GO
INSERT [dbo].[AirportLocalizations] ([AirportId], [LanguageId], [Name], [Description]) VALUES (6, 1, N'Dnipropetrovsk International Airport', N'Dnipropetrovsk International Airport is an airport serving Dnipro, a city in Dnipropetrovsk Oblast, Ukraine. It is located 15 kilometres (8 NM) southeast from the city center.')
GO
INSERT [dbo].[AirportLocalizations] ([AirportId], [LanguageId], [Name], [Description]) VALUES (7, 1, N'Zaporizhia International Airport', N'Zaporizhia International Airport is the international airport that serves Zaporizhia, Ukraine one of three airfields around the city. The aircraft engine factory Motor Sich has its base here.')
GO
INSERT [dbo].[AirportLocalizations] ([AirportId], [LanguageId], [Name], [Description]) VALUES (8, 1, N'Lviv Danylo Halytskyi International Airport', N'Lviv Danylo Halytskyi International Airport is an international airport in Lviv, Ukraine. The airport is located 6 kilometres (3.7 mi) from central Lviv. The airport is named after King Daniel of Galicia, the historical founder of the city in 1256 AD.')
GO
INSERT [dbo].[AirportLocalizations] ([AirportId], [LanguageId], [Name], [Description]) VALUES (9, 1, N'Odessa International Airport', N'Odessa International Airport is an international airport of Odessa, the third largest city of Ukraine, located 7 km (4.3 mi) southwest from its city centre.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 12, N'Airbus A320', N'The Airbus A320 family consists of short- to medium-range, narrow-body, commercial passenger twin-engine jet airliners manufactured by Airbus. The A320s are also named A320ceo (current engine option) after the introduction of the A320neo (new engine option). Final assembly of the family takes place in Toulouse, France, and Hamburg, Germany. A plant in Tianjin, China, has also been producing aircraft for Chinese airlines since 2009, while a final assembly facility in Mobile, Alabama, United States, delivered its first A321 in April 2016.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 13, N'Airbus A330-300', N'The Airbus A330 is a medium- to long-range wide-body twin-engine jet airliner made by Airbus. Versions of the A330 have a range of 5,000 to 13,430 kilometres (2,700 to 7,250 nmi; 3,110 to 8,350 mi) and can accommodate up to 335 passengers in a two-class layout or carry 70 tonnes (154,000 lb) of cargo.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 14, N'Аn-148', N'The Antonov An-148 is a regional jet airliner designed by the Ukrainian Antonov company and produced by Antonov itself and, until 2017, also on outsource by Russia''s Voronezh Aircraft Production Association. Development of the aircraft was started in the 1990s, and the maiden flight took place on 17 December 2004. The aircraft completed its certification programme on 26 February 2007.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 15, N'Comac ARJ21', N'The Comac ARJ21 Xiangfeng is a twin-engined regional jet, manufactured by the Chinese aerospace company Comac.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 16, N'BAC One-Eleven', N'The British Aircraft Corporation One-Eleven, also known as the BAC-111 or BAC 1-11, is a British short-range jet airliner. It is the second short-haul jet airliner to enter service, following the French Sud Aviation Caravelle. The aircraft was also produced under license in Romania during the 1980s as the Rombac One-Eleven.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 17, N'Bombardier CRJ-100/200', N'The Bombardier CRJ100 and CRJ200 are a family of regional airliners manufactured by Bombardier, and based on the Canadair Challenger business jet. These regional jet models were formerly known as the Canadair CRJ100 and CRJ200.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 18, N'Boeing 737-700', N'The Boeing 737 is a short- to medium-range twinjet narrow-body airliner developed and manufactured by Boeing Commercial Airplanes in the United States. Originally developed as a shorter, lower-cost twin-engine airliner derived from the 707 and 727, the 737 has developed into a family of ten passenger models with capacities from 85 to 215 passengers. The 737 is Boeing''s only narrow-body airliner in production, with the 737 Next Generation (-700, -800, and -900ER) and the re-engined and redesigned 737 MAX variants currently being built.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 19, N'Boeing 777-9', N'The Boeing 777X is a new series of the long-range wide-body twin-engine Boeing 777 family that is under development by Boeing Commercial Airplanes. The 777X is to feature GE9X new engines, new composite wings with folding wingtips, a denser cabin, and technologies from the Boeing 787. The 777X series was launched in November 2013 with two variants: the 777-8 and the 777-9. The 777-8 has seating for 365 and range of over 8,700 nmi (16,110 km) and the 777-9 has seating for 414 and range of over 7,600 nmi (14,075 km).')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 20, N'Fokker 100', N'The Fokker 100 is a medium-sized, twin-turbofan jet airliner from Fokker, the largest such aircraft built by the company before its bankruptcy in 1996. The type possessed low operational costs and initially had scant competition in the 100-seat short-range regional jet class, contributing to strong sales upon introduction in the late 1980s.')
GO
INSERT [dbo].[PlaneLocalizations] ([LanguageId], [PlaneId], [Name], [Description]) VALUES (1, 21, N'Saab 2000', N'The Saab 2000 is a twin-engined high-speed turboprop airliner built by Saab. It is designed to carry 50–58 passengers and cruise at a speed of 665 km/h (413 mph). Production took place in Linköping in southern Sweden. The Saab 2000 first flew in March 1992 and was certified in 1994.')
GO
SET IDENTITY_INSERT [dbo].[Sectors] ON 
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (28, 1, 4, 1, 10, 3, 12)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (29, 5, 10, 1, 10, 2, 12)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (30, 11, 21, 1, 10, 1, 12)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (31, 1, 11, 1, 6, 1, 13)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (32, 1, 6, 1, 6, 2, 14)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (33, 7, 13, 1, 8, 1, 14)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (34, 1, 6, 1, 4, 3, 15)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (35, 7, 15, 1, 6, 2, 15)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (36, 1, 3, 1, 4, 3, 16)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (37, 4, 12, 1, 6, 1, 16)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (38, 1, 13, 1, 4, 1, 17)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (39, 1, 4, 1, 10, 2, 18)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (40, 5, 17, 1, 10, 1, 18)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (41, 1, 21, 1, 8, 1, 19)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (42, 1, 9, 1, 6, 1, 20)
GO
INSERT [dbo].[Sectors] ([Id], [FromRow], [ToRow], [FromPlace], [ToPlace], [SeatTypeId], [PlaneId]) VALUES (43, 1, 6, 1, 6, 1, 21)
GO
SET IDENTITY_INSERT [dbo].[Sectors] OFF
GO
