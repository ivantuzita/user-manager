﻿namespace UserManager.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException(string name) : base($"{name} was not found") {

        }
    }
}