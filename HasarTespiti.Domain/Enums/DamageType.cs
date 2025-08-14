using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasarTespiti.Domain.Enums
{
    public enum DamageType
    {
        Broken = 0,
        Dent = 1,
        Scratch = 2,
        MissingPart = 3
       
    }
}














// hasar tespitinde kullanılan hasar türlerini standartlaştırmak
//predictionda DamageType alanı bu enum tipinde olur.
//veri tutarlılığı sağlar .   string yerin enum kullanmak.



//  Veritabanında int olarak saklanır, kodda anlamlı isimlerle kullanılır.
//  "Prediction" entity'sindeki "DamageType" alanı bu enum tipindedir.
//  Bu enum, HasarTespiti.Domain.Enums namespace’i altında yer alır.
//  Yeni bir hasar türü eklenmesi gerektiğinde buraya ekleme yapılır.