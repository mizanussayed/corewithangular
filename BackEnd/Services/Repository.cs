using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BackEnd.Services;
public interface IServices<T> where T : class
{
    IEnumerable<T> GettAll();
    T GetById(Object Id);
    void Insert(T obj);
    void Update(T obj);
    void Delele(Object Id);
}


public class Services<T> : IServices<T> where T : class
{

    private readonly Context _context = null;
    private readonly DbSet<T> _table = null;


    public Services()
    {
        _context = new Context();
        _table = _context.Set<T>();
    }

    public Services(Context context)
    {
        _context = context;
        _table = context.Set<T>();
    }
    public void Delele(object Id)
    {
        T deletable = _table.Find(Id);
        _table.Remove(deletable);
        _context.SaveChanges();
    }

    public T GetById(object Id)
    {
        return _table.Find(Id);
    }

    public IEnumerable<T> GettAll()
    {
        return _table.ToList();
    }

    public void Insert(T obj)
    {
        _table.Add(obj);
        _context.SaveChanges();
    }


    public void Update(T obj)
    {
        _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }
}

