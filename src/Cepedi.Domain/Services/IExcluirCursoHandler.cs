﻿namespace Cepedi.Domain;

public interface IExcluirCursoHandler
{
    Task<int> ExcluirCursoAsync(int idCurso);
}