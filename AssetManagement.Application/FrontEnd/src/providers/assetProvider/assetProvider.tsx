import axios from "axios";
import { stringify } from "query-string";
import { CreateParams, CreateResult, DataProvider, DeleteManyParams, DeleteManyResult, DeleteParams, DeleteResult, GetManyParams, GetManyReferenceParams, GetManyReferenceResult, GetManyResult, GetOneParams, GetOneResult, RaRecord, UpdateManyParams, UpdateManyResult, UpdateParams, UpdateResult, fetchUtils } from "ra-core";
import config from "../../connectionConfigs/config.json";

export const assetProvider: DataProvider = {
   getList: (resource, params) => {
      const { page, perPage } = params.pagination;
      console.log(params);
      const { field, order } = params.sort;
      const query = {
         end: JSON.stringify((page) * perPage),
         start: JSON.stringify((page - 1) * perPage),
         sort: field,
         order: order
      };
      const url = `${config.api.base}/api/${resource}?${stringify(query)}`;
      console.log(url);
      return axios(url).then(res => {
         console.log(res);
         return Promise.resolve({ data: res.data.assets, total: res.data.total });
      });
   },
   getOne: function <RecordType extends RaRecord = any>(resource: string, params: GetOneParams<any>): Promise<GetOneResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
   getMany: function <RecordType extends RaRecord = any>(resource: string, params: GetManyParams): Promise<GetManyResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
   getManyReference: function <RecordType extends RaRecord = any>(resource: string, params: GetManyReferenceParams): Promise<GetManyReferenceResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
   update: (resource, params) =>
      fetchUtils.fetchJson(`${config.api.base}/api/${resource}/${params.id}`, {
         method: 'PUT',
         body: JSON.stringify(params.data),
      }).then(({ json }) => ({ data: json })),
   updateMany: function <RecordType extends RaRecord = any>(resource: string, params: UpdateManyParams<any>): Promise<UpdateManyResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
   create: function <RecordType extends RaRecord = any>(resource: string, params: CreateParams<any>): Promise<CreateResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
   delete: function <RecordType extends RaRecord = any>(resource: string, params: DeleteParams<RecordType>): Promise<DeleteResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
   deleteMany: function <RecordType extends RaRecord = any>(resource: string, params: DeleteManyParams<RecordType>): Promise<DeleteManyResult<RecordType>> {
      throw new Error("Function not implemented.");
   },
};