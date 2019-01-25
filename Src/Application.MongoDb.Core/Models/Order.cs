﻿using System;
using System.Collections.Generic;
using Application.MongoDb.Core.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KNN.NULLPrinter.Core.Models
{
    public class Order : IEntity<ObjectId>
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId Id { get; set; }

        public string code { get; set; } 
        public bool status { get; set; }  //open = 1 or close = 0

        public List<OrderDetail> items { get; set; } = new List<OrderDetail>();

        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class OrderDetail
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId Id { get; set; }

        public string code { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public bool status { get; set; }  //open = 1 or close = 0
    }
}
