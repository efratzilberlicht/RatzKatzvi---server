using BL.Convertors;
using DL;
using Dto;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public static class SubjectsBL
    {
        //Add 
        public static void AddSubject(Subjects1 subject)
        {
            Subjects newSubject = SubjectsConvertor.ConvertToDL(subject);
            SubjectsDL.AddSubject(newSubject);     
        }
        //Update
        public static void UpdateSubject(Subjects1 s)
        {
            
           SubjectsDL.UpdateSubject(SubjectsConvertor.ConvertToDL(s));
        }
        //Delete 
        public static void DeleteSubject(Subjects1 subject)
        {
            Subjects newSubject = SubjectsConvertor.ConvertToDL(subject);
            ItemsSubjectBL.DeleteItemsSubjectBySubjectId(newSubject.SubjectId);

            SubjectsDL.DeleteSubject(newSubject);
        }
        //GetById
        public static Subjects1 GetSubjectById(int subjectId)
        {
            return SubjectsConvertor.ConvertToDto(SubjectsDL.GeSubjectById(subjectId));
        }
        //GetOnlyParents
        public static List<Subjects1> GeSubjectOnlyParents()
        {
            return SubjectsConvertor.ConvertToListDto(DL.SubjectsDL.GeSubjectOnlyParents());
        }
        //GetByParentId
        public static List<Subjects1> GeSubjectByParentId(int parentId)
        {
            return SubjectsConvertor.ConvertToListDto(DL.SubjectsDL.GeSubjectByParentId(parentId)??new List<Subjects>());
        }
        //GetByName
        public static Subjects1 GetSubjectByName(string subject)
        {
            List<Subjects> lst = new List<Subjects>(SubjectsDL.GetAllSubjects());
            return SubjectsConvertor.ConvertToDto(lst.Where(k => k.Subject.Equals(subject)).FirstOrDefault()??new Subjects());
        }
        //GetContainName
        public static List<Subjects1> GetSubjectContainText(string text)
        {
            List<Subjects> lst = new List<Subjects>(SubjectsDL.GetAllSubjects());
            return SubjectsConvertor.ConvertToListDto(lst.Where(k => k.Subject.Contains(text)).ToList()??new List<Subjects>());
        }
        //GetAll
        public static List<Subjects1> GetAllSubjects()
        {
            return SubjectsConvertor.ConvertToListDto(SubjectsDL.GetAllSubjects()??new List<Subjects>());
        }
    }
}
