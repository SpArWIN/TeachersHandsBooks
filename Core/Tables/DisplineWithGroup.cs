﻿using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace TeachersHandsBooks.Core.Tables
{
    public class DisplineWithGroup
    {

        [Key] public int IDW { get; set; }



        public virtual Group Group { get; set; }



        public virtual Displine Displine { get; set; }



        public virtual KTP KTP { get; set; }


        public static void DeleteFolders(string groupName, string disciplineName)
        {
            string RootFolderPath = "Folderess";
            string GroupFolderPath = Path.Combine(RootFolderPath, groupName);
            string DisciplineFolderPath = Path.Combine(GroupFolderPath, disciplineName);

            // Проверяем существование папки дисциплины внутри папки группы
            if (Directory.Exists(DisciplineFolderPath))
            {
                // Удаляем папку дисциплины
                Directory.Delete(DisciplineFolderPath, true);
            }

            // Проверяем существование папки группы
            if (Directory.Exists(GroupFolderPath))
            {
                // Проверяем пуста ли папка группы после удаления папки дисциплины
                if (Directory.GetDirectories(GroupFolderPath).Length == 0 &&
                    Directory.GetFiles(GroupFolderPath).Length == 0)
                {
                    // Удаляем папку группы, если она пуста
                    Directory.Delete(GroupFolderPath);
                }
            }
        }




        public static void CreateFolders(string NameGroup, string NameDispline, string KtpPath)
        {
            using (var context = new DatabaseContext())
            {
                string RootFolderPath = "Folderess";
                string GroupFolderPath = Path.Combine(RootFolderPath, NameGroup);
                if (!Directory.Exists(GroupFolderPath))
                {
                    Directory.CreateDirectory(GroupFolderPath);
                }

                // Создание папки дисциплины внутри папки группы, если она не существует
                string DisciplineFolderPath = Path.Combine(GroupFolderPath, NameDispline);
                if (!Directory.Exists(DisciplineFolderPath))
                {
                    Directory.CreateDirectory(DisciplineFolderPath);
                }

                // Копирование файла КТП внутрь папки дисциплины
                string DestinationFilePath = Path.Combine(DisciplineFolderPath, Path.GetFileName(KtpPath));

                if (File.Exists(DestinationFilePath))
                {
                    // Удаление существующего файла
                    File.Delete(DestinationFilePath);
                }

                File.Copy(KtpPath, DestinationFilePath);
            }

        }

        public static void AddCon(int IDGroup, int IdDispline, int IDKTP)
        {
            using (var context = new DatabaseContext())
            {

                var group = context.Groups.FirstOrDefault(g => g.ID == IDGroup);
                var discipline = context.Displines.FirstOrDefault(d => d.ID == IdDispline);
                var ktp = context.kTPs.FirstOrDefault(k => k.ID == IDKTP);



                var newDisplineWithGroup = new DisplineWithGroup
                {
                    Group = group,
                    Displine = discipline,
                    KTP = ktp
                };

                context.ConnectWithGroup.Add(newDisplineWithGroup);
                context.SaveChanges();
            }
        }

    }
}
