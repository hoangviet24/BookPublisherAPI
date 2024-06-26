﻿using BookPublisher.Models;
using BookPublisher.Models.DTO;

namespace BookPublisher.Repository
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GetAll();
        AuthorDTO GetById(int id);
        AuthorDTO GetByName(string name);
        AddAuthorDTO AddAuthor(AddAuthorDTO addBookDTO);
        AddAuthorDTO? Put(int id,AddAuthorDTO addBookDTO);
        Author? Delete(int id);
    }
}
