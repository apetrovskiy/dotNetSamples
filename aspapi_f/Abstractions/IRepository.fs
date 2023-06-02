type IRepository<T> =
    { GetAllAsync(): Task<IEnumerable<T>>
     GetAsync(id:Guid): Task<T?>
     AddAsync(entity:T):Task
     UpdateAsync(entity:T):Task
     DeleteAsync(id:Guid):Task}
