﻿using Dwellers.Common.DAL.Models.Notes;

namespace Dwellers.Notes.Contracts.Responses
{
    public record AddNoteResponse(
        NoteEntity Note
        );
}
