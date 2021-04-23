using System.Collections.Generic;
using System.Linq;
using Dto;
namespace BL
{
    public class SearchesBL
    {
        public static SearchResult SearchText(string text)
        {
            List<Subjects1> subjects = new List<Subjects1>();
            List<WordLocation1> wordLocation = new List<WordLocation1>();
            List<int> subjectIds = new List<int>();
            List<int> presearcheIds = new List<int>();
            SearchResult searchResult = new SearchResult();
            var presearchestRes = PreSerchesBL.GetWordIdByName(text);
            if (presearchestRes.Count() > 0)
                presearcheIds.AddRange(presearchestRes.OrderByDescending(pre=>pre.SearchedCounter).Select(pre => pre.Id));
            var subjectRes = SubjectsBL.GetSubjectByName(text);
            if (!string.IsNullOrEmpty(subjectRes.Subject))
                subjects.Add(subjectRes);
            var listSubjectRes = SubjectsBL.GetSubjectContainText(text).Where(res => !string.IsNullOrEmpty(res.Subject) && res.Subject != text);
            if (listSubjectRes.Count() > 0)
                subjects.AddRange(listSubjectRes);
            subjectIds.AddRange(subjects.Select(subject => subject.SubjectId).ToList() ?? new List<int>());
            wordLocation = WordLocationBL.GetAll().Where(w => subjectIds.Contains(w.SubjectId ?? 0) || presearcheIds.Contains(w.SearchId ?? 0)).ToList();
            if (presearcheIds == null || presearcheIds.Count == 0)
            {
                searchResult.bookPages.AddRange(Convertors.BookPagesConvertor.ConvertToListDto(DL.SearchesDL.SearchInBooks(text)));
            }
            else
            {
                foreach (var item in wordLocation.OrderByDescending(w=>w.Counter))
                {
                    searchResult.bookPages.Add(BookPagesBL.GetSentencesByBookIDPageIDSentencesID(item.BookItemID, item.BookPage, item.BookSenteceID));
                }

            }
            searchResult.subjects = subjects;
            foreach (var preSearch in presearchestRes)
            {
                preSearch.SearchedCounter++;
                PreSerchesBL.UpdatePreSerch(preSearch);
            }
            foreach (var subject in subjects)
            {
                subject.SearchedCounter++;
                SubjectsBL.UpdateSubject(subject);
            }
            return searchResult;
        }
    }
}
