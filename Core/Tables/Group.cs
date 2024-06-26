﻿using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TeachersHandsBooks.Core.Tables
{
    public class Group
    {

        [Key] public int ID { get; set; }
        public string NameGroup { get; set; }

        public static void RemoveToDatabase(string groupName)
        {
            using (var context = new DatabaseContext())
            {
                var groupToRemove = context.Groups.FirstOrDefault(g => g.NameGroup == groupName);

                if (groupToRemove != null)
                {
                    context.Groups.Remove(groupToRemove);
                    context.SaveChanges();
                }
                else
                {
                    return;

                }
            }
        }
        public static void AddGroupToDatabase(string groupName)
        {
            using (var context = new DatabaseContext())
            {
                // Создание новой записи в базе данных через EF
                var newGroup = new Group { NameGroup = groupName };

                context.Groups.Add(newGroup);
                context.SaveChanges();
            }
        }

    }
}
