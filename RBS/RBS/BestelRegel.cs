﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class BestelRegel
    {
        private int tafelId;
        private int productId;
        private int aantal;
        private int bestelId;
        private string comment;
        private int status;
        private int id;
        private DateTime tijd;

        public BestelRegel(int tafelId, int productId, int aantal,  int bestelId, string comment, int status, int id, DateTime tijd)
        {
            this.tafelId = tafelId;
            this.productId = productId;
            this.aantal = aantal;
            this.bestelId = bestelId;
            this.comment = comment;
            this.status = status;
            this.id = id;
            this.tijd = tijd;
        }

        public int TafelId
        {
            get { return tafelId; }
            set { tafelId = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public int Aantal
        {
            get { return aantal; }
            set { aantal = value; }
        }

        public int BestelId
        {
            get { return bestelId; }
            set { bestelId = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Tijd
        {
            get { return tijd; }
            set { tijd = value; }
        }
    }
}
