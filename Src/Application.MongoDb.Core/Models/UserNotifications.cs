﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KNN.NULLPrinter.Core.Models
{
    public class UserNotifications
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }
        public string Title { get; set; }
        public string Remarks { get; set; }
        public string DetailUrl { get; set; }

        [BsonDateTimeOptions]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public ObjectId AppUsers_Id { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
