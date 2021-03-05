using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Perguntas    {
        public Perguntas(){}
        public int idPergunta { get; set; } 
        public string titulo { get; set; } 
        public string pergunta { get; set; } 
        public List<string> respostas { get; set; } 
        public List<string> respostaCerta { get; set; } 

        public bool respondida{get; set;}
    }
