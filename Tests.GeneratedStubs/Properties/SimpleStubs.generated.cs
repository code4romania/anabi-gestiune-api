using  System;
using  System.Runtime.CompilerServices;
using  Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Anabi.DataAccess.Abstractions.Repositories
{
    [CompilerGenerated]
    public class StubIGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StubContainer<StubIGenericRepository<T>> _stubs = new StubContainer<StubIGenericRepository<T>>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Linq.IQueryable<T> global::Anabi.DataAccess.Abstractions.Repositories.IGenericRepository<T>.GetAll()
        {
            GetAll_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetAll_Delegate>("GetAll");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetAll_Delegate>("GetAll", out del))
                {
                    return default(global::System.Linq.IQueryable<T>);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Linq.IQueryable<T> GetAll_Delegate();

        public StubIGenericRepository<T> GetAll(GetAll_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Linq.IQueryable<T> global::Anabi.DataAccess.Abstractions.Repositories.IGenericRepository<T>.FindBy(global::System.Linq.Expressions.Expression<global::System.Func<T, bool>> predicate)
        {
            FindBy_ExpressionOfFuncOfTBoolean_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<FindBy_ExpressionOfFuncOfTBoolean_Delegate>("FindBy");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<FindBy_ExpressionOfFuncOfTBoolean_Delegate>("FindBy", out del))
                {
                    return default(global::System.Linq.IQueryable<T>);
                }
            }

            return del.Invoke(predicate);
        }

        public delegate global::System.Linq.IQueryable<T> FindBy_ExpressionOfFuncOfTBoolean_Delegate(global::System.Linq.Expressions.Expression<global::System.Func<T, bool>> predicate);

        public StubIGenericRepository<T> FindBy(FindBy_ExpressionOfFuncOfTBoolean_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Anabi.DataAccess.Abstractions.Repositories.IGenericRepository<T>.AddAsync(T entity)
        {
            AddAsync_T_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddAsync_T_Delegate>("AddAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddAsync_T_Delegate>("AddAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(entity);
        }

        public delegate global::System.Threading.Tasks.Task AddAsync_T_Delegate(T entity);

        public StubIGenericRepository<T> AddAsync(AddAsync_T_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Anabi.DataAccess.Abstractions.Repositories.IGenericRepository<T>.DeleteAsync(T entity)
        {
            DeleteAsync_T_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<DeleteAsync_T_Delegate>("DeleteAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<DeleteAsync_T_Delegate>("DeleteAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(entity);
        }

        public delegate global::System.Threading.Tasks.Task DeleteAsync_T_Delegate(T entity);

        public StubIGenericRepository<T> DeleteAsync(DeleteAsync_T_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Anabi.DataAccess.Abstractions.Repositories.IGenericRepository<T>.EditAsync(T entity)
        {
            EditAsync_T_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<EditAsync_T_Delegate>("EditAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<EditAsync_T_Delegate>("EditAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(entity);
        }

        public delegate global::System.Threading.Tasks.Task EditAsync_T_Delegate(T entity);

        public StubIGenericRepository<T> EditAsync(EditAsync_T_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Anabi.DataAccess.Abstractions.Repositories.IGenericRepository<T>.SaveAsync()
        {
            SaveAsync_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<SaveAsync_Delegate>("SaveAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<SaveAsync_Delegate>("SaveAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task SaveAsync_Delegate();

        public StubIGenericRepository<T> SaveAsync(SaveAsync_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIGenericRepository(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    [CompilerGenerated]
    public class StubIEntityConfig : IEntityConfig
    {
        private readonly StubContainer<StubIEntityConfig> _stubs = new StubContainer<StubIEntityConfig>();

        public MockBehavior MockBehavior { get; set; }

        void global::Anabi.DataAccess.Ef.EntityConfigurators.IEntityConfig.SetupEntity(global::Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            SetupEntity_ModelBuilder_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<SetupEntity_ModelBuilder_Delegate>("SetupEntity");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<SetupEntity_ModelBuilder_Delegate>("SetupEntity", out del))
                {
                    return;
                }
            }

            del.Invoke(modelBuilder);
        }

        public delegate void SetupEntity_ModelBuilder_Delegate(global::Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder);

        public StubIEntityConfig SetupEntity(SetupEntity_ModelBuilder_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIEntityConfig(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}